package com.example.session5;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.AppCompatButton;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModel;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.viewpager2.widget.ViewPager2;

import android.os.Bundle;
import android.view.View;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class MainActivity extends AppCompatActivity {

    private IApiService apiService;
    private ViewPager2 viewPager2;
    private androidx.recyclerview.widget.RecyclerView eventsList;
    private EventsAdapter eventsAdapter;
    private NewsAdapter newsAdapter;
    private NewsPagerAdapter NewsPagerAdapter;
    private NewsViewModel newsViewModel;
    private EventsViewModel eventsViewModel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl("http://192.168.0.108:5000/")
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        apiService = retrofit.create(IApiService.class);

        newsViewModel = new ViewModelProvider(this, new ViewModelProvider.Factory() {
            @NonNull
            @Override
            public <T extends ViewModel> T create(@NonNull Class<T> modelClass) {
                return (T) new NewsViewModel(apiService);
            }
        }).get(NewsViewModel.class);

        eventsViewModel = new ViewModelProvider(this, new ViewModelProvider.Factory() {
            @NonNull
            @Override
            public <T extends ViewModel> T create(@NonNull Class<T> modelClass) {
                return (T) new EventsViewModel(apiService);
            }
        }).get(EventsViewModel.class);

        viewPager2 = findViewById(R.id.viewpager2);
        eventsList = findViewById(R.id.events_list);

        newsAdapter = new NewsAdapter(new ArrayList<>());
        eventsAdapter = new EventsAdapter(new ArrayList<>());
        eventsList.setLayoutManager(new LinearLayoutManager(this));
        eventsList.setAdapter(eventsAdapter);

        newsViewModel.getNews().observe(this, newsItems -> {
            if (newsItems != null) {
                newsAdapter.updateNews(newsItems);
                NewsPagerAdapter = new NewsPagerAdapter(this, createNewsFragments(newsItems));
                viewPager2.setAdapter(NewsPagerAdapter);
            }
        });

        eventsViewModel.getEvents().observe(this, eventItems -> {
            if (eventItems != null) {
                eventsAdapter.updateData(eventItems);
            }
        });

        //viewPager2.setVisibility(View.VISIBLE);
    }

    private List<Fragment> createNewsFragments(List<NewsItem> newsItems) {
        List<Fragment> fragments = new ArrayList<>();
        for (NewsItem news : newsItems) {
            fragments.add(NewsFragment.newInstance(news));
        }
        return fragments;
    }

    public void onEvents(View view)
    {
        viewPager2.setVisibility(View.GONE);
        eventsList.setVisibility(View.VISIBLE);
    }

    public void onNews(View view)
    {
        eventsList.setVisibility(View.GONE);
        viewPager2.setVisibility(View.VISIBLE);
    }
}
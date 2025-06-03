package com.example.session5;

import android.util.Log;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class NewsViewModel extends ViewModel {
    private MutableLiveData<List<NewsItem>> newsList = new MutableLiveData<>();

    private IApiService apiService;

    public NewsViewModel(IApiService api) {
        apiService = api;
        loadNews();
    }

    public LiveData<List<NewsItem>> getNews() {
        return newsList;
    }

    private void loadNews() {
        apiService.getNews().enqueue(new Callback<List<NewsItem>>() {
            @Override
            public void onResponse(Call<List<NewsItem>> call, Response<List<NewsItem>> response) {
                if (response.isSuccessful() && response.body() != null) {
                    newsList.setValue(response.body());
                }
                else {
                    Log.e("NewsViewModel", "Response unsuccessful or body null!");
                    newsList.setValue(new ArrayList<>());
                }
            }

            @Override
            public void onFailure(Call<List<NewsItem>> call, Throwable t) {
                Log.e("NewsViewModel", "Error", t);
                newsList.setValue(new ArrayList<>());
            }
        });
    }
}

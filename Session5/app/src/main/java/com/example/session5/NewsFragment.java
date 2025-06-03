package com.example.session5;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import com.bumptech.glide.Glide;

public class NewsFragment extends Fragment {
    private static final String ARG_NEWS = "news_item";
    private NewsItem newsItem;
    public static NewsFragment newInstance(NewsItem news) {
        NewsFragment fragment = new NewsFragment();
        Bundle args = new Bundle();
        args.putSerializable(ARG_NEWS, news);
        fragment.setArguments(args);
        return fragment;
    }
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null){
            newsItem = (NewsItem) getArguments().getSerializable(ARG_NEWS);
        }
    }
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.item_new, container, false);
        ImageView imageView = view.findViewById(R.id.news_image);
        TextView titleView = view.findViewById(R.id.news_name);
        TextView descriptionView = view.findViewById(R.id.news_description);
        TextView likesView = view.findViewById(R.id.news_likes);
        TextView dislikesView = view.findViewById(R.id.news_dislikes);
        TextView dateView = view.findViewById(R.id.news_date);
        if (newsItem != null) {
            titleView.setText(newsItem.name);
            descriptionView.setText(newsItem.description);
            likesView.setText("+" + newsItem.likes);
            dislikesView.setText("-" + newsItem.dislikes);
            dateView.setText(newsItem.date);
            Glide.with(this).load(newsItem.image).into(imageView);
        }
        return view;
    }
}

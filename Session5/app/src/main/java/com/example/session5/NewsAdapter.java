package com.example.session5;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;

import java.util.List;

public class NewsAdapter extends RecyclerView.Adapter<NewsAdapter.NewsViewHolder> {
    private List<NewsItem> newsList;
    public NewsAdapter(List<NewsItem> newsList) { this.newsList = newsList; }
    @NonNull
    @Override
    public NewsViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_new, parent, false);
        return new NewsViewHolder(view);
    }
    public void updateNews(List<NewsItem> NewsItemsList) {
        this.newsList = NewsItemsList;
        notifyDataSetChanged();
    }
    @Override
    public void onBindViewHolder(@NonNull NewsViewHolder holder, int position) {
        NewsItem news = newsList.get(position);
        holder.name.setText(news.name);
        holder.description.setText(news.description);
        holder.date.setText(news.date);
        holder.likes.setText(news.likes);
        holder.dislikes.setText(news.dislikes);
        Glide.with(holder.itemView.getContext()).load(news.image).into(holder.image);
    }
    @Override
    public int getItemCount() {
        return newsList.size();
    }
    public static class NewsViewHolder extends RecyclerView.ViewHolder {
        TextView name, description, likes, dislikes, date;
        ImageView image;
        public NewsViewHolder(@NonNull View itemView) {
            super(itemView);
            name = itemView.findViewById(R.id.news_name);
            description = itemView.findViewById(R.id.news_description);
            likes = itemView.findViewById(R.id.news_likes);
            dislikes = itemView.findViewById(R.id.news_dislikes);
            date = itemView.findViewById(R.id.news_date);
            image = itemView.findViewById(R.id.news_image);
        }
    }
}

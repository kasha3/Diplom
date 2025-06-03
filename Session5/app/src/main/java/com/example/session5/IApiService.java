package com.example.session5;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface IApiService {
    @GET("/api/v1/news")
    Call<List<NewsItem>> getNews();

    @GET("/api/v1/events")
    Call<List<EventItem>> getEvents();
}

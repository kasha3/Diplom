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

public class EventsViewModel extends ViewModel {
    private MutableLiveData<List<EventItem>> eventsList = new MutableLiveData<>();

    private IApiService apiService;

    public EventsViewModel(IApiService apiService) {
        this.apiService = apiService;
        loadEvents();
    }

    public LiveData<List<EventItem>> getEvents() { return eventsList; }

    private void loadEvents() {
        apiService.getEvents().enqueue(new Callback<List<EventItem>>() {
            @Override
            public void onResponse(Call<List<EventItem>> call, Response<List<EventItem>> response) {
                if (response.isSuccessful() && response.body() != null) {
                    eventsList.setValue(response.body());
                } else {
                    Log.e("EventsViewModel", "Error: Response unsuccessful or empty body");
                    eventsList.setValue(new ArrayList<>());
                }
            }

            @Override
            public void onFailure(Call<List<EventItem>> call, Throwable t) {
                Log.e("EventsViewModel", "Error loading events", t);
                eventsList.setValue(new ArrayList<>());
            }
        });
    }
}

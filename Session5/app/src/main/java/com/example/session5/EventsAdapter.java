package com.example.session5;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class EventsAdapter extends RecyclerView.Adapter<EventsAdapter.EventViewHolder> {
    private List<EventItem> eventList;

    public EventsAdapter(List<EventItem> eventList) { this.eventList = eventList; }

    @NonNull
    @Override
    public EventViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_event, parent, false);
        return new EventViewHolder(view);
    }

    @Override
    public int getItemCount() {
        return eventList.size();
    }

    public void updateData(List<EventItem> newEvents) {
        this.eventList.clear();
        this.eventList.addAll(newEvents);
        notifyDataSetChanged();
    }

    @Override
    public void onBindViewHolder(@NonNull EventViewHolder holder, int position) {
        EventItem event = eventList.get(position);
        if (event != null) {
            holder.name.setText(event.name);
            holder.description.setText(event.description);
            holder.date.setText(event.date);
            holder.author.setText(event.authorName);
        }
    }

    public static class EventViewHolder extends RecyclerView.ViewHolder {
        TextView name, description, date, author;
        public EventViewHolder(@NonNull View itemView) {
            super(itemView);
            name = itemView.findViewById(R.id.event_name);
            description = itemView.findViewById(R.id.event_description);
            date = itemView.findViewById(R.id.event_date);
            author = itemView.findViewById(R.id.event_author);
        }
    }
}

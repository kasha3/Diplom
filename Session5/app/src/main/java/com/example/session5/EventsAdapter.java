package com.example.session5;

import android.content.Context;
import android.content.Intent;
import android.provider.CalendarContract;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.Locale;

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

            if (event.isAddedToCalendar){
                holder.star.setImageResource(R.drawable.ic_star_enabled);
            } else holder.star.setImageResource(R.drawable.ic_star_disabled);

            holder.star.setOnClickListener(v -> {
                Context context = holder.itemView.getContext();

                if (!event.isAddedToCalendar) {
                    long startMillis = parseDateToMillis(event.date);
                    long endMillis = startMillis + 60 * 60 * 1000;
                    Intent intent = new Intent(Intent.ACTION_INSERT);
                    intent.setData(CalendarContract.Events.CONTENT_URI);
                    intent.putExtra(CalendarContract.Events.TITLE, event.name);
                    intent.putExtra(CalendarContract.Events.DESCRIPTION, event.description);
                    intent.putExtra(CalendarContract.EXTRA_EVENT_BEGIN_TIME, startMillis);
                    intent.putExtra(CalendarContract.EXTRA_EVENT_END_TIME, endMillis);
                    context.startActivity(intent);
                    event.isAddedToCalendar = true;
                    holder.star.setImageResource(R.drawable.ic_star_enabled);
                } else {
                    Toast.makeText(context, "Событие уже добавлено", Toast.LENGTH_SHORT).show();
                }
            });
        }
    }

    private long parseDateToMillis(String dateString) {
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm", Locale.getDefault());
        try {
            Date date = sdf.parse(dateString);
            return date != null ? date.getTime() : System.currentTimeMillis();
        } catch (ParseException e) {
            e.printStackTrace();
            return System.currentTimeMillis();
        }
    }

    public static class EventViewHolder extends RecyclerView.ViewHolder {
        TextView name, description, date, author;
        ImageButton star;
        public EventViewHolder(@NonNull View itemView) {
            super(itemView);
            name = itemView.findViewById(R.id.event_name);
            description = itemView.findViewById(R.id.event_description);
            date = itemView.findViewById(R.id.event_date);
            author = itemView.findViewById(R.id.event_author);
            star = itemView.findViewById(R.id.btnAddToCalendar);
        }
    }
}

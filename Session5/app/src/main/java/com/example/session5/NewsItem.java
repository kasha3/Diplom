package com.example.session5;

import java.io.Serializable;

public class NewsItem implements Serializable {
    public int id;
    public String name;
    public String date;
    public String description;
    public String image;
    public int likes;
    public int dislikes;
}

package com.example.session5;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.viewpager2.adapter.FragmentStateAdapter;

import java.util.List;

public class NewsPagerAdapter extends FragmentStateAdapter {
    private List<Fragment> fragmentList;
    public NewsPagerAdapter(@NonNull MainActivity fragment, List<Fragment> fragments) {
        super(fragment);
        this.fragmentList = fragments;
    }

    @NonNull
    @Override
    public Fragment createFragment(int position) { return fragmentList.get(position); }

    @Override
    public int getItemCount() { return fragmentList.size(); }
}

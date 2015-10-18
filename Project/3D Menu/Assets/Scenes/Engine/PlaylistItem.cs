﻿using UnityEngine;
using System.Collections;

public class PlaylistItem : MonoBehaviour {
	string location;
	string genre;
	string artist;
	string album;
	string title;

	public PlaylistItem(string location, string genre, string artist, string album, string title){
		this.location = location;
		this.album = album;
		this.artist = artist;
		this.genre = genre;
		this.title = title;

	}

	PlaylistItem(string location){
		this.location = location;
		this.album = "Unknown album";
		this.artist = "Unknown artist";
		this.genre = "Unknown genre";
		this.title = "Unknown title";

	}
}
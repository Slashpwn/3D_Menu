using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Id3;

public class Main : MonoBehaviour {
	List <PlaylistItem> songpool = new List<PlaylistItem>();
	Playlist currentPlaylist;
	PlaylistItem currentSong;
	bool playlistPlay = true;
	bool shuffle = false;
	int count = 0;
	List<Playlist> allPlaylists = new List<Playlist>();
	AudioSource player;
	AudioClip clp;

	//GameObject cube = new GameObject("cb");

	// Use this for initialization
	void Start () {
		//cube.AddComponent (MeshFilter);
		//cube.AddComponent (MeshCollider);
				//player = GetComponent<AudioSource> ();
				loadAllPlaylists ();
				loadSongpool ();

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyUp("a")){
			prev ();
			Debug.Log ("Previous");
		}
		if(Input.GetKeyUp("s")){
			play ();
			Debug.Log ("Play");
		}
		if(Input.GetKeyUp("d")){
			pause ();
			Debug.Log ("Pause");
		}
		if(Input.GetKeyUp("f")){
		next ();
			Debug.Log ("Next");
		}
		if(Input.GetKeyUp("x")){
			shuffleTogle ();
			Debug.Log ("Shuffle: "+shuffle);
		}
		if(Input.GetKeyUp("c")){
			//searchForFiles ("C:/Users/M/Downloads/2003 - Andante");
			//searchForFiles("C:/Users/M/Downloads/Radiohead - The Best Of Radiohead (2008) 320 vtwin88cube");
			//searchForFiles("C:/Users/M/Downloads/Green Day - Greatest Hits (2CD)  2010");
			//searchForFiles("C:/Users/M/Downloads/TAYLOR SWIFT - DISCOGRAPHY (2006-14) [CHANNEL NEO]");
		}
	}

	void selector(){
		foreach(PlaylistItem p in songpool){

		}
	}

	void play(){
		player.Play();
	}

	void pause(){
		player.Pause ();

	}

	void next(){
		if(playlistPlay && !shuffle){

				currentSong = currentPlaylist.getNext(count);
				Debug.Log (currentSong.toString());
			count++;
		}

	}

	void prev(){


	}

	void shuffleTogle(){
		shuffle = !shuffle;

	}



	void loadAllPlaylists(){


	}

	void savePlaylist(Playlist pl){

	}

	void newPlaylist(string newName){
		Playlist newPl = new Playlist (newName);
		allPlaylists.Add (newPl);
		currentPlaylist = newPl;

	}

	void deletePlaylist(Playlist PL){
		allPlaylists.Remove (PL);

	}

	void searchForFiles(string baseDirectory){
		DirectoryInfo dir = new DirectoryInfo(baseDirectory);
		DirectoryInfo[] directories = dir.GetDirectories();
		foreach (DirectoryInfo d in directories) {
			searchForFiles (d.FullName);		
		
		}

		string fn = dir.FullName;
		string[] musicFiles = Directory.GetFiles (@fn,"*.mp3");
		foreach (string musicFile in musicFiles) {
			using (var mp3 = new Mp3File(musicFile)) {

				Id3Tag tag = mp3.GetTag (Id3TagFamily.FileStartTag);

				if(tag != null){

					/*
					Debug.Log ("Title: " + tag.Title.Value);
					Debug.Log ("Artist: " + tag.Artists.Value);
					Debug.Log ("Album: " + tag.Album.Value);
					Debug.Log("Genre: " + tag.Genre.Value);
*/

					PlaylistItem newest = new PlaylistItem(musicFile,tag.Genre.Value, tag.Artists.Value, tag.Album.Value, tag.Title.Value);
					Debug.Log (newest.toString());
					songpool.Add(newest);
				}			
				
				
				
			}
		}


	}

	void loadSongpool(){


	}

}

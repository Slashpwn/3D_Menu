using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	ArrayList songpool;
	Playlist currentPlaylist;
	PlaylistItem currentSong;
	bool playlistPlay = true;
	bool shuffle = false;
	ArrayList allPlaylists;

	// Use this for initialization
	void Start () {
		loadAllPlaylists ();
		loadSongpool ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void play(){

	}

	void pause(){


	}

	void next(){


	}

	void prev(){


	}

	void shuffleTogle(){


	}

	void getNext(){


	}

	void loadAllPlaylists(){


	}

	void savePlaylist(Playlist pl){

	}

	void newPlaylist(string newName){
		Playlist newPl = new Playlist (newName);
		allPlaylists.Add (newPl);

	}

	void deletePlaylist(){


	}

	void searchForFiles(string baseDirectory){


	}

	void loadSongpool(){


	}

}

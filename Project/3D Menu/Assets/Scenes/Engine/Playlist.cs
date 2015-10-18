using UnityEngine;
using System.Collections;

public class Playlist : MonoBehaviour {
	public ArrayList PLI;
	public PlaylistItem[] PL;
	public string name;
	public int length;
	public int lastPlay;

	public Playlist(string name){
		this.name = name;
	
	}

	void add(){


	}

	void remove(){


	}

	void getNoOfItems(){


	}

	PlaylistItem getNext(int count){

		return PL [count + 1];
	}

	void update(){
		PL = (PlaylistItem[])PLI.ToArray ();

	}
}

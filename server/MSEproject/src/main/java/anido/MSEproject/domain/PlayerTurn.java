	package anido.MSEproject.domain;

public class Player {
	private String id;
	private String name;
	private boolean isMyTurn;
	
	// constructor, getter, setter
	public Player(String id, String name, boolean isMyTurn) {
		super();
		this.id = id;
		this.name = name;
		this.isMyTurn = isMyTurn;
	}
	
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public boolean isMyTurn() {
		return isMyTurn;
	}
	public void setMyTurn(boolean isMyTurn) {
		this.isMyTurn = isMyTurn;
	}

	
}

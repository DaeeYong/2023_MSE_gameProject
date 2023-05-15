	package anido.MSEproject.domain;

public class Player extends User{
	private boolean myTurn;

	private int x;
	private int y;

	// constructor, getter, setter
	public Player(){}
	public Player(String name, boolean isMyTurn, int x, int y) {
		super();
		this.id = id;
		this.name = name;
		this.isMyTurn = isMyTurn;
		this.x = x;
		this.y = y;
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

	public int getX() {
		return x;
	}

	public void setX(int x) {
		this.x = x;
	}

	public int getY() {
		return y;
	}

	public void setY(int y) {
		this.y = y;
	}
}

package anido.MSEproject.domain;

public class Player extends User{
    private int x;
    private int y;
    private boolean myTurn;

    public Player(User user, int x, int y, boolean myTurn){
        setName(user.getName());
        setId(user.getId());
        this.x = x;
        this.y = y;
        this.myTurn = myTurn;
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

    public boolean isMyTurn() {
        return myTurn;
    }

    public void setMyTurn(boolean myTurn) {
        this.myTurn = myTurn;
    }
}

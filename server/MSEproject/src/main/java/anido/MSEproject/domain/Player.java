package anido.MSEproject.domain;

public class Player extends User{
    private String action = null; //moving, blocking
    private int row; //현재위치?
    private int col; //현재위치

    public Player(User user, int row, int col){
        setName(user.getName());
        setId(user.getId());
        this.row = row;
        this.col = col;
    }

    public int getRow() {
        return row;
    }

    public void setRow(int row) {
        this.row = row;
    }

    public int getCol() {
        return col;
    }

    public void setCol(int col) {
        this.col = col;
    }

    public String getAction() {
        return action;
    }

    public void setAction(String action) {
        this.action = action;
    }
}

package anido.MSEproject.domain;

public class Player extends User{
    private int xNow;
    private int yNow;
    private int xPre;
    private int yPre;
    private boolean myTurn;

    public Player(User user, int x, int y, boolean myTurn){
        setName(user.getName());
        setId(user.getId());
        this.xNow = x; //현재 위치 정보
        this.yNow = y; //현재 위치 정보
        this.xPre = -1;//이전 위치 정보
        this.yPre = -1; //이전 위치 정보
        this.myTurn = myTurn;
    }

    public int getxNow() {
        return xNow;
    }

    public void setxNow(int xNow) {
        this.xNow = xNow;
    }

    public int getyNow() {
        return yNow;
    }

    public void setyNow(int yNow) {
        this.yNow = yNow;
    }

    public int getxPre() {
        return xPre;
    }

    public void setxPre(int xPre) {
        this.xPre = xPre;
    }

    public int getyPre() {
        return yPre;
    }

    public void setyPre(int yPre) {
        this.yPre = yPre;
    }

    public boolean isMyTurn() {
        return myTurn;
    }

    public void setMyTurn(boolean myTurn) {
        this.myTurn = myTurn;
    }
}

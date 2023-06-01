package anido.MSEproject.domain;

public class Player extends User{
    private String action; //moving, blocking
    private int posX; //현재위치?
    private int posY; //현재위치

    public Player(User user, int posX, int posY){
        setName(user.getName());
        setId(user.getId());
        this.posX = posX;
        this.posY = posY;
    }

    public int getPosX() {
        return posX;
    }

    public void setPosX(int posX) {
        this.posX = posX;
    }

    public int getPosY() {
        return posY;
    }

    public void setPosY(int posY) {
        this.posY = posY;
    }

    public String getAction() {
        return action;
    }

    public void setAction(String action) {
        this.action = action;
    }
}

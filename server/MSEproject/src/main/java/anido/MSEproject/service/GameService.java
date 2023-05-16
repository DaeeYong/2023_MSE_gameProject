package anido.MSEproject.service;

import anido.MSEproject.domain.Board;
import anido.MSEproject.domain.Player;
import ch.qos.logback.core.spi.FilterReply;

public class GameService {
    private Board boardOrigin;
    private Board boardBuffer;
    private Player player1;
    private Player player2;

    public GameService(Player player1, Player player2){
        this.player1 = player1;
        this.player2 = player2;
        this.boardOrigin = new Board();
        this.boardBuffer = new Board();
    }
    public void boardUpdate(){}
    public void setPlayerTurn(Player player, boolean setTurn){

    }
    public void InitPlayerTurn(){

    }
    public void updatePlayerCoordinate(Player player, int x, int y){

    }
}

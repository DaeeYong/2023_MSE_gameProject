package anido.MSEproject.service;

import anido.MSEproject.domain.Board;
import anido.MSEproject.domain.Player;
import ch.qos.logback.core.spi.FilterReply;

import java.util.ArrayList;
import java.util.List;

public class GameService {
    private Board boardOrigin;
    private Board boardBuffer;
    private List<Player> players;

    public GameService(){
        this.boardOrigin = new Board();
        this.boardBuffer = new Board();
        this.players = new ArrayList<>();
    }
    //player 위치 보드에 반영
    //board 업데이트 -> 플레이어 좌표 업데이트

    public void boardUpdate(Player player){
        int p_xPre = player.getxPre();
        int p_yPre = player.getyPre();
        int p_xNow = player.getxNow();
        int p_yNow = player.getyNow();

        boardOrigin.setBoardValue(p_yPre, p_xPre, 0);
        boardOrigin.setBoardValue(p_yNow, p_xNow, 1);   

    }
    public void setPlayerTurn(Player player, boolean setTurn){
        player.setMyTurn(setTurn);
    }

    /*
     * id값 비교 -> id절대값 낮은 플레이어가 첫 턴
     */
    public void InitPlayerTurn() {

    }

    public List<Player> getPlayers() {
        return players;
    }
    public void addPlayer(Player player){
        players.add(player);
    }
    public void setPlayers(List<Player> players) {
        this.players = players;
    }

    public void updatePlayerCoordinate(Player player, int x, int y) {

    }
}

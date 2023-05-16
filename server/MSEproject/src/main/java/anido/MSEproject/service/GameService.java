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
        if (player1.getId() < player2.getId()) {
            setPlayerTurn(player1, true); 
            setPlayerTurn(player2, false); 
        } else {
            setPlayerTurn(player1, false); 
            setPlayerTurn(player2, true); 
        }
    }

    public void updatePlayerCoordinate(Player player, int x, int y) {
        player.setxPre(player.getxNow());
        player.setyPre(player.getyNow());
        player.setxNow(x);
        player.setyNow(y);

        boardUpdate(player);
    }
}

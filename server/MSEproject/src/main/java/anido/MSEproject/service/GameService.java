package anido.MSEproject.service;

import anido.MSEproject.controller.PlayerForm;
import anido.MSEproject.domain.Board;
import anido.MSEproject.domain.Obstacle;
import anido.MSEproject.domain.Player;
import anido.MSEproject.domain.WhoTurn;

import java.util.ArrayList;
import java.util.List;

public class GameService {
    private String turn;
    private Board boardOrigin;
    private Board boardBuffer;
    //일단 사이즈 최대 2 가정
    private List<Player> players;

    public GameService(){
        this.boardOrigin = new Board();
        this.boardBuffer = new Board();
        this.players = new ArrayList<>();
        this.turn = "player1";
    }

    public String getTurn() {
        return turn;
    }

    public void setTurn(String turn) {
        this.turn = turn;
    }

    public Player getPlayerInfo(int playerNumber){
        Player player = players.get(playerNumber-1);
        return player;
    }
    public void updatePlayerInfo(PlayerForm playerForm){
        Player player = getPlayerInfo(playerForm.getPlayerNumber());
        player.setPosX(playerForm.getX1());
        player.setPosY(playerForm.getX1());
        player.setAction(playerForm.getAction());
    }

    public Boolean isValidInstall(Obstacle obstacle){
        boardOrigin.copyTo(boardBuffer); //원래 보드 상태 복사

    }
    public void installObstacle(Obstacle obstacle){
        boardOrigin.setBoardValue(obstacle.getY1(), obstacle.getX1(), 3);
        boardOrigin.setBoardValue(obstacle.getY2(), obstacle.getX2(), 3);
    }
    //player 위치 보드에 반영
    //board 업데이트 -> 플레이어 좌표 업데이트
    // player1 : 1, player2 : 2, 장애물 : 3
    public void boardUpdate(int x, int y, int value){
        boardOrigin.setBoardValue(y,x,value);
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

}

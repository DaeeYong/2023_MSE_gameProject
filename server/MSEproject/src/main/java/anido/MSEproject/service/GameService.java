package anido.MSEproject.service;

import anido.MSEproject.Form.PlayerForm;
import anido.MSEproject.domain.Board;
import anido.MSEproject.domain.Obstacle;
import anido.MSEproject.domain.Player;
import anido.MSEproject.template.Pair;

import java.util.*;

public class GameService {
    
    //상대좌표
    static final int[] dx = {-1,0,1,0};
    static final int[] dy = {0,1,0,-1};
    //player turn
    private String turn;
    private Board boardOrigin;
    private Board vist;
    //일단 사이즈 최대 2 가정
    private List<Player> players;

    public GameService(){
        this.boardOrigin = new Board();
        this.vist = new Board();
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
        player.setRow(playerForm.getRow1());
        player.setCol(playerForm.getCol1());
        player.setAction(playerForm.getAction());
    }

    public Boolean isValidInstall(Obstacle obstacle){
        //player1에 대해서 테스트
        Boolean result1 = _isValidInstall(getPlayerInfo(1).getRow(),
                getPlayerInfo(1).getCol(),obstacle, 16);

        //player2에 대해서 테스트
        Boolean result2 = _isValidInstall(getPlayerInfo(2).getRow(),
                getPlayerInfo(2).getCol(),obstacle, 0);
        
        //결과
        if(result1 == true && result2 == true) return true;
        return false;
    }
    private Boolean _isValidInstall(int x, int y, Obstacle obstacle, int dest_y_idx){
        vist.clear();
        Stack<Pair> stack = new Stack<>();

        //시작 위치
        vist.setBoardValue(x, y,1);
        stack.push(new Pair(x, y));
        //DFS
        int flag = 0;
        while (!stack.isEmpty()){
            Pair cur = stack.peek(); stack.pop();
            for(int direction = 0; direction < 4; direction++){
                int nx = cur.x + dx[direction];
                int ny = cur.y + dy[direction];
                //조건 확인
                if(nx < 0 || nx >= Board.BOARD_SIZE || ny <0 || ny >= Board.BOARD_SIZE) continue;
                if(boardOrigin.getBoardValue(nx,ny) == 1 || vist.getBoardValue(nx,ny) == 1) continue;
                if(nx == dest_y_idx){
                    flag = 1;
                    break;
                }
                vist.setBoardValue(nx, ny,1);
                stack.push(new Pair(nx, ny));
            }
            if(flag == 1) break;
        }
        //다시 원래대로
        vist.setBoardValue(x, y,0);

        if(flag == 1) return true;
        else return false;

    }
    public void installObstacle(Obstacle obstacle){
        boardOrigin.setBoardValue(obstacle.getRow1(), obstacle.getCol1(), 3);
        boardOrigin.setBoardValue(obstacle.getRow2(), obstacle.getCol2(), 3);
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

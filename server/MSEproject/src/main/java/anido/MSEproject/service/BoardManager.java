package anido.MSEproject.service;

import anido.MSEproject.domain.Board;
import anido.MSEproject.domain.BoardOrigin;
import anido.MSEproject.domain.Player;
import anido.MSEproject.domain.BoardBuffer;
import org.springframework.data.util.Pair;

import java.util.LinkedList;
import java.util.Queue;

public class BoardManager {

    private final int PLAYER1 = 1;
    private final int PLAYER2 = 2;
    private final int OBSTACLE = 3;

    private final int[] dx = {-1,0,1,0};
    private final int[] dy = {0,1,0,-1};

    private Board boardOrign;
    private Board boardBuffer;

    private Player player1;
    private Player player2;

    public BoardManager(BoardOrigin boardOrigin, BoardBuffer boardBuffer) {
        this.boardOrign = boardOrigin;
        this.boardBuffer = boardBuffer;
        this.player1 = new Player();
        this.player2 = new Player();
    }



    public boolean isValid(int x1, int y1, int x2, int y2){
        boardOrign.copyTo(boardBuffer);
        boardBuffer.setBoardValue(x1,y1,OBSTACLE);
        boardBuffer.setBoardValue(x2,y2,OBSTACLE);

        Queue<Pair> queue = new LinkedList<>();
        //player1 -> player2
        queue.add(new Pair(player1.getX(), player1.getX()));

        while(!queue.isEmpty()){
            Pair cur = queue.poll();
            for(int direction = 0; direction < 4; direction++){
                int nx = cur.x + dx[direction];
                int ny  = cur.y + dy[direction];
                if(nx < 0 || nx > boardBuffer.getBOARD_SIZE() || ny < 0 || ny > boardBuffer.getBOARD_SIZE()) continue;
                if()
            }
        }
        //player2 -> player2

    }

    static class Pair{
        int x;
        int y;

        public Pair(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}

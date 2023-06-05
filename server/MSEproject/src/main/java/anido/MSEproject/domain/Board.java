package anido.MSEproject.domain;

public class Board {

    final static int BOARD_SIZE = 17;
    private int[][] board = new int[BOARD_SIZE][BOARD_SIZE];

    public Board(){
        for(int i=0; i<BOARD_SIZE; i++){
            for(int j=0; j<BOARD_SIZE; j++){
                this.board[i][j] = 0;
            }
        }
    }

    public void clearBoard(){
        for(int i=0; i<BOARD_SIZE; i++){
            for(int j=0; j<BOARD_SIZE; j++){
                this.board[i][j] = 0;
            }
        }
    }

    public int getBOARD_SIZE() {
        return BOARD_SIZE;
    }

    public int[][] getBoard() {
        return board;
    }

    public void clear(){
        for(int i=0; i<BOARD_SIZE; i++){
            for(int j=0; j<BOARD_SIZE; j++){
                setBoardValue(i,j,0);
            }
        }
    }
    public void installObstacle(Obstacle obstacle){
        setBoardValue(obstacle.getY1(), obstacle.getX1(), 1);
        setBoardValue(obstacle.getY2(), obstacle.getX2(), 1);
    }
    public void setBoardValue(int y, int x, int value){
        board[y][x] = value;
    }
    public int getBoardValue(int y, int x){
        return board[y][x];
    }

    public void copyTo(Board dest){
        for(int i=0; i<BOARD_SIZE; i++){
            for(int j=0; j<BOARD_SIZE; j++){
                dest.setBoardValue(i,j, board[i][j]);
            }
        }
    }
}

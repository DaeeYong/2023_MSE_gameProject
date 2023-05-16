package anido.MSEproject.domain;

public class Board {

    final int BOARD_SIZE = 17;
    private int[][] board = new int[BOARD_SIZE][BOARD_SIZE];

    public Board(){
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
    public void setBoardValue(int x, int y, int value){
        board[x][y] = value;
    }
    public int getBoardValue(int x, int y){
        return board[x][y];
    }

    public void copyTo(Board dest){
        for(int i=0; i<BOARD_SIZE; i++){
            for(int j=0; j<BOARD_SIZE; j++){
                dest.setBoardValue(i,j, board[i][j]);
            }
        }
    }
}

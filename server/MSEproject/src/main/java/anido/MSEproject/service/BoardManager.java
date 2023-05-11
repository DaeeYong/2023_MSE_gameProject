package anido.MSEproject.service;

import anido.MSEproject.domain.Board;
import anido.MSEproject.domain.OriginBoard;
import anido.MSEproject.domain.TestBoard;

public class BoardManager {
    private OriginBoard originBoard;
    private TestBoard testBoard;

    public BoardManager(OriginBoard originBoard, TestBoard testBoard) {
        this.originBoard = originBoard;
        this.testBoard = testBoard;
    }

    public OriginBoard getOriginBoard() {
        return originBoard;
    }

    public void setOriginBoard(OriginBoard originBoard) {
        this.originBoard = originBoard;
    }

    public TestBoard getTestBoard() {
        return testBoard;
    }

    public void setTestBoard(TestBoard testBoard) {
        this.testBoard = testBoard;
    }
}

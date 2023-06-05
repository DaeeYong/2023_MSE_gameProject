package anido.MSEproject.controller;

import anido.MSEproject.domain.Obstacle;
import anido.MSEproject.domain.Player;
import anido.MSEproject.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;

import anido.MSEproject.service.GameService;
import org.springframework.web.bind.annotation.*;

import javax.swing.*;
import java.util.ArrayList;
import java.util.List;

@Controller
public class GameController {
    private final GameService gameService;
    private final UserService userService;
    private final Obstacle obstacle;

    @Autowired
    public GameController(GameService gameService, UserService userService, Obstacle obstacle) {
        this.gameService = gameService;
        this.userService = userService;
        this.obstacle = obstacle;
    }

    //플레이어 좌표 초기 세팅
    @GetMapping("/game/init")
    @ResponseBody
    public Validation initGame(){
        Validation validation = new Validation();

        Player player1 = getPlayerInfo(1);
        Player player2 = getPlayerInfo(2);
        
        //플레이어 초기 좌표 세팅
        player1.setRow(8);
        player1.setCol(0);

        player2.setRow(8);
        player2.setCol(16);

        validation.setValid(true);
        
        return validation;
    }
    //플레이어 정보 조회
    /*
    @GetMapping("/current/player-turn-Info")
    @ResponseBody
    public Player getPlayerTurnInfo(@RequestParam("playerNumber") int playerNumber){
        return gameService.getPlayerInfo(playerNumber);
    }
    */

    //순서 set
    @PostMapping("/current/player-turn-set")
    @ResponseBody
    public Validation setPlayerTurnInfo(@RequestBody TurnForm turnForm) {
        Validation validation = new Validation();
        gameService.setTurn(turnForm.getTurn());

        validation.setValid(true);

        return validation;
    }

    //순서 조회 + 블럭 조회까지 추가해야함...
    @GetMapping("/current/player-turn-info")
    @ResponseBody
    public TurnForm getPlayerTurnInfo() {
        TurnForm turnForm = new TurnForm();
        turnForm.setTurn(gameService.getTurn());
        return turnForm;
    }

    //플레이어 이동 업데이트
    /*
    private int playerNumber;
    private String action;
    private int x1;
    private int y1;
    private int x2;
    private int y2;
     */
    @PostMapping("/move/update/player")
    @ResponseBody
    public Validation updatePlayerInfo(@RequestBody PlayerForm playerForm) {
        Validation validation = new Validation();
        gameService.updatePlayerInfo(playerForm); //블럭설치 처리x
        validation.setValid(true);
        return validation;
    }

    //플레이어 이동 조회
    @GetMapping("/move/info/player")
    @ResponseBody
    public Player getPlayerInfo(@RequestParam(name="playerNum") int playerNum) {
        Player player = gameService.getPlayerInfo(playerNum);
        return player;
    }
    //플레이어 장애물 설치
    /*
    input : {playerForm}
        private int playerNumber;
        private String action;
        private int x1; //플레이어 위치
        private int y1; //플레이어 위치
        private int x2; //장애물 설치는 여기까지 사용
        private int y2; //장애물 설치는 여기까지 사용
    output : { "valid" : true | false }
     */
    //유효성 검사
    @PostMapping("/install/block/valid")
    @ResponseBody
    public Validation IsValidInstall(@RequestBody Obstacle obstacle){
        Boolean result = gameService.isValidInstall(obstacle);

        Validation validation = new Validation();
        validation.setValid(result);

        return validation;
    }

    @PostMapping("/install/block")
    @ResponseBody
    public Validation installBlock(@RequestBody Obstacle obstacle){
        gameService.installObstacle(obstacle);
        Validation validation = new Validation();
        validation.setValid(true);

        return validation;
    }
    
    /*
    @PostMapping("/install/block/validation")
    @ResponseBody
    public Validation installBlockValidation(@RequestBody PlayerForm playerForm){
        obstacle.setObstacle(playerForm.getX1(), playerForm.getY1(),
                playerForm.getX2(), playerForm.getY2());

        Validation validation = new Validation();
        boolean result =  gameService.isValidInstall(obstacle);
        if(result == true) validation.setValid(true);
        else validation.setValid(false);

        return validation;

    }
*/
    @GetMapping("/findAllPlayer")
    @ResponseBody
    public List<Player> getAllPlayer(){
        return gameService.getPlayers();
    }

}

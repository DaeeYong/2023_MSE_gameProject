package anido.MSEproject.controller;

import anido.MSEproject.domain.Player;
import anido.MSEproject.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;

import anido.MSEproject.service.GameService;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@Controller
public class GameController {
    private final GameService gameService;
    private final UserService userService;

    @Autowired
    public GameController(GameService gameService, UserService userService) {
        this.gameService = gameService;
        this.userService = userService;
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

    //순서 조회
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
    public Player getPlayerInfo(@RequestParam int playerNum) {
        Player player = gameService.getPlayerInfo(playerNum);
        return player;
    }

    @GetMapping("/findAllPlayer")
    @ResponseBody
    public List<Player> getAllPlayer(){
        return gameService.getPlayers();
    }
    /*
    @GetMapping("/update/player1")
    public ResponseEntity<?> updateLocationPlayer1(@RequestParam int x, @RequestParam int y) {
        gameService.updatePlayerCoordinate(player1, x, y);
        return ResponseEntity.ok().body("{valid: true}");
      //return new ResponseEntity<>(player1,HttpStatus.OK);
    }

    @GetMapping("/update/player2")
    public ResponseEntity<?> updateLocationPlayer2(@RequestParam int x, @RequestParam int y) {
        gameService.updatePlayerCoordinate(player2, x, y);
        return ResponseEntity.ok().body("{valid: true}");
        //return new ResponseEntity<>(player2,HttpStatus.OK);
    }

    @GetMapping("/current/player1")
    public ResponseEntity<?> fetchLocationPlayer1() {
        int x = player1.getxNow();
        int y = player1.getyNow();
        return ResponseEntity.ok().body("{x: " + x + ", y: " + y + "}");
    }

    //test
    @GetMapping("/current/player2")
    public ResponseEntity<?> fetchLocationPlayer2() {
        int x = player2.getxNow();
        int y = player2.getyNow();
        return ResponseEntity.ok().body("{x: " + x + ", y: " + y + "}");
    }
     */
}

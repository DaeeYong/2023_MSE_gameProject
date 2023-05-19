package anido.MSEproject.controller;

import anido.MSEproject.domain.User;
import anido.MSEproject.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import anido.MSEproject.domain.Player;
import anido.MSEproject.service.GameService;

import java.util.List;

@Controller
public class GameController {
    private final GameService gameService;
    private final UserService userService;

    private Player player1;
    private Player player2;

    @Autowired
    public GameController(GameService gameService, UserService userService) {
        this.gameService = gameService;
        this.userService = userService;
        User user1 = new User();
        user1.setName("rabbit");
        user1.setId(1L);

        User user2 = new User();
        user2.setName("tiger");
        user2.setId(2L);

        this.player1 = new Player(user1,0,10,false);
        this.player2 = new Player(user2,16,10,false);
    }

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
/*
    @GetMapping("/current/player1")
    public ResponseEntity<?> fetchLocationPlayer1() {
        int x = player1.getxNow();
        int y = player1.getyNow();
        return ResponseEntity.ok().body("{x: " + x + ", y: " + y + "}");
    }
/*
    @GetMapping("/current/player2")
    @ResponseBody
    public Player fetchLocationPlayer2() {
        int x = player2.getxNow();
        int y = player2.getyNow();
        return player2;
        //return ResponseEntity.ok().body("{x: " + x + ", y: " + y + "}");
    }
    */
    @GetMapping("/current/player1")
    @ResponseBody
    public CoordForm fetchLocationPlayer1(){
        CoordForm coordForm = new CoordForm();
        coordForm.setX(player1.getxNow());
        coordForm.setY(player1.getyNow());
        return coordForm;
    }
    @GetMapping("/current/player2")
    @ResponseBody
    public CoordForm fetchLocationPlayer2(){
        CoordForm coordForm = new CoordForm();
        coordForm.setX(player2.getxNow());
        coordForm.setY(player2.getyNow());
        return coordForm;
    }
}
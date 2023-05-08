package anido.MSEproject.domain;

import java.util.Map;

import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;


@RestController
@RequestMapping("/stats") // URL : localhost:8080/stats/player/...
public class PlayerController {
	
	private final PlayerService playerService;
	
	public PlayerController(PlayerService playerService) {
        this.playerService = playerService;
    }
	
// 	 player 객체를 받아서 controller에서 win인지 아닌지 상태 판별할거임

//   RequestBody

//	{
//		  "playerId" : "",
//		  "wins" : true or false
//	}

	// create
    @PostMapping("/player/create")
    public void createPlayerStats(@RequestBody Player player) {
    	playerService.createStats(player);
    }
	
	// read
	@GetMapping("/player/{id}")	
	public Player readPlayerStats(@PathVariable("id") long id) {
		return playerService.readStats(id);
	}

	// update
	@PutMapping("/player/{id}")
	public void updatePlayerStats(@PathVariable("id") long id, @RequestBody Map<String, Boolean> request) {
		boolean isWin = request.get("wins");
		playerService.updatePlayerStats(id,isWin);
	}
	
	// delete
	@DeleteMapping("/player/{id}")
	public void deletePlayerStats(@PathVariable("id") long id) {
		playerService.deleteStats(id);
	}
}

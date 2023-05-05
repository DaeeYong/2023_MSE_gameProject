package anido.MSEproject.service;

import java.util.NoSuchElementException;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import anido.MSEproject.domain.Player;
import anido.MSEproject.repository.PlayerRepository;



//jpa 라이브러리 설치안돼있음
//build.gradle -> implementation 'org.springframework.boot:spring-boot-starter-data-jpa' 했는데..
@Service
public class PlayerService {
	
    @Autowired
    private PlayerRepository playerRepository;
    private float winningRate = 0.0f;

    // create player's status
    public void createStats(Player p) {
    	playerRepository.save(p);
    	System.out.print("player has created");
    }
    
    // read player's status
    public Player readStats(long id) {
    	Optional<Player> playerOptional = playerRepository.findById(id);
    	
    	if(playerOptional.isPresent()) {
    		Player player = playerOptional.get(); 
    		
    		String playerName = player.getName();
    		int playerWins = player.getWins();
    		int playerLoses = player.getLosses();
    		float playerRates = player.getRates();
    		System.out.print("Player stats:\n"
    				+ "Name:["+playerName+"]\n"
    				+ "Winning rates:["+playerRates+"]\n"
    				+ "Wins:["+playerWins+"]\n"
    				+ "Loses:["+playerLoses+"]\n");
    		return player;
    	}
    	else {
    		throw new NoSuchElementException("Player with id " + id + " does not exist");
    	}
    }
    
    // update player's status
    public void updatePlayerStats(long id, boolean isWin) {
        Optional<Player> playerOptional = playerRepository.findById(id); 

        Player player = playerOptional.get();
       
        if(isWin) {
        	player.setWins(player.getWins()+1);
        }
        else {
        	player.setLosses(player.getLosses()+1);
        }
        
        winningRate = (float) player.getWins() / (player.getWins() + player.getLosses()); 

        player.setRates(winningRate);

        playerRepository.save(player);
        System.out.print("player has updated");
    }
  
    
    // delete player's status
    public void deleteStats(long id) {
    	Optional<Player> playerOptional = playerRepository.findById(id);
  
    	if(playerOptional.isPresent()) {
    		playerRepository.deleteById(id);
    		System.out.print("player has deleted");
    	}
    	else {
    		throw new NoSuchElementException("Player with id " + id + " does not exist");
    	}
    }
}
package anido.MSEproject.domain;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table(name = "player")
public class Player {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "name", nullable = false)
    private String name;

	@Column(name = "wins", nullable = false)
    private int wins;

    @Column(name = "losses", nullable = false)
    private int losses;
    
    @Column(name="rates",nullable = false)
    private float rates;


 // Getter, Setter, Constructor
 public Player(Long id, String name, int wins, int losses, float rates) {
 	super();
 	this.id = id;
 	this.name = name;
 	this.wins = wins;
 	this.losses = losses;
 	this.rates = rates;
 }

 public Long getId() {
 	return id;
 }

 public void setId(Long id) {
 	this.id = id;
 }

 public String getName() {
 	return name;
 }

 public void setName(String name) {
 	this.name = name;
 }

 public int getWins() {
 	return wins;
 }

 public void setWins(int wins) {
 	this.wins = wins;
 }

 public int getLosses() {
 	return losses;
 }

 public void setLosses(int losses) {
 	this.losses = losses;
 }

 public float getRates() {
 	return rates;
 }

 public void setRates(float rates) {
 	this.rates = rates;
 }
}




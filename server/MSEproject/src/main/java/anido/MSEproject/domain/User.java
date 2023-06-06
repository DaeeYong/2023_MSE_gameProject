package anido.MSEproject.domain;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;

@Entity
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Table(name="user_table")
// @Embeddable
public class User {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name="user_name")
    private String name;

    @Column(name="user_password")
    private String password;

    @Column(name="user_win")
    private int win;

    @Column(name="user_lose")
    private int lose;


//
//    public String getPassword() {
//        return password;
//    }
//
//    public void setPassword(String password) {
//        this.password = password;
//    }
//
//    public Long getId() {
//        return id;
//    }
//    public void setId(Long id) {
//        this.id = id;
//    }
//    public String getName() {
//        return name;
//    }
//    public void setName(String name) {
//        this.name = name;
//    }
//
//    public int getWin() {
//        return win;
//    }
//
//    public void setWin(int win) {
//        this.win = win;
//    }
//
//    public int getLose() {
//        return lose;
//    }
//
//    public void setLose(int lose) {
//        this.lose = lose;
//    }
}

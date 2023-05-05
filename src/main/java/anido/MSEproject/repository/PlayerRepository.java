package anido.MSEproject.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import anido.MSEproject.domain.Player;

// jpa 라이브러리 설치안돼있음
@Repository
public interface PlayerRepository extends JpaRepository<Player, Long> {

}
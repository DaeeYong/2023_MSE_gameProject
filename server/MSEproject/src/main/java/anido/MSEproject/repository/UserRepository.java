package anido.MSEproject.repository;

import anido.MSEproject.domain.User;

import java.lang.reflect.Member;
import java.util.List;
import java.util.Optional;
import org.springframework.data.jpa.repository.JpaRepository
import org.springframework.stereotype.Repository

@Repository
public interface UserRepository extends JpaRepository<User, Long> {

    //회원을 저장하면 저장된 유저 반환
    User save(User user);

    //id로 유저 조회
    Optional<User> findById(Long id);

    //name으로 유저 조회
    Optional<User> findByName(String name);

    //모든 유저 조회
    List<User> findAll();
}

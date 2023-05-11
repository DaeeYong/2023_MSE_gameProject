package anido.MSEproject.service;

import anido.MSEproject.domain.User;
import anido.MSEproject.repository.UserRepository;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserService {

	@Autowired
    private final UserRepository userRepository;

    public UserService(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    /*
    <회원가입>
    회원가입 성공시 true
    회원가입 실패시 false
    중복 name 허용x
     */
    public Boolean join(User user) {
        boolean isDuplicate = userRepository.findByName(user.getName()).isPresent();

        if(isDuplicate) return false;
        userRepository.save(user);
        return true;
    }


    /*
    전체 user 조회
     */
    public List<User> findAllUsers(){
        return userRepository.findAll();
    }

    /*
    id로 user 한명 조회
     */
    public Optional<User> findOne(Long userId){
        return userRepository.findById(userId);
    }

    //이름으로 user 조회
    public Optional<User> findByName(String name){
        return userRepository.findByName(name);
    }
}

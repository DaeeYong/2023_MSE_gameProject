package anido.MSEproject.controller;

import anido.MSEproject.domain.User;
import anido.MSEproject.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@Controller
public class UserController {

	@Autowired
    private final UserService userService;
    private final Validation validation = new Validation();

    @Autowired
    public UserController(UserService userService) {
        this.userService = userService;
    }

    /*
     * 로그인 기능
     * method : get
     * url : http://localhost:8080/sign-in
     * 주의점 : url은 로컬에서 실행하는 경우를 가정한 것
     * input : name
     * output : {"valid" : {Boolean} } //로그인에 성공한 경우 true, 실패한 경우 false
     */
    @GetMapping("sign-in")
    @ResponseBody
    public Validation signIn(@RequestParam("name")String name){
        Optional<User> result = userService.findByName(name);

        if(result.isPresent()) validation.setValid(true);
        else validation.setValid(false);

        return validation;
    }
    /*
     * 회원가입 기능
     * method : post
     * url : http://localhost:8080/sign-up
     * 주의점 : url은 로컬에서 실행하는 경우를 가정한 것
     * input : { "name" : {string} }
     * output : {"valid" : {Boolean} } //회원가입에 성공한 경우 true, 실패한 경우 false
     */
    @PostMapping("sign-up")
    @ResponseBody
    public Validation signUp(@RequestBody UserForm userForm){
        User user = new User();

        user.setName(userForm.getName());
        Boolean result = userService.join(user);
        if(result == false){
            validation.setValid(false);
            return validation;
        }

        validation.setValid(true);
        return validation;
    }
    /*
     * 전체 유저 조회
     * method : get
     * url : http://localhost:8080/find-all
     * 주의점 : url은 로컬에서 실행하는 경우를 가정한 것
     * output 예시 : [
        {
            "id": 1,
            "name": "성호"
        },
        {
            "id": 2,
            "name": "팔달"
        },
        {
            "id": 3,
            "name": "율곡"
         }
     ]
     */
    @GetMapping("find-all")
    @ResponseBody
    public List<User> findAll(){
        return userService.findAllUsers();
    }

}
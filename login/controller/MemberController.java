package hello.hellospring.controller;

import hello.hellospring.domain.Member;
import hello.hellospring.service.MemberService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.List;

/*
url에 직접 입력 : get 방식(데이터를 조회할 때)
data를 form 같은데 넣어서 전달할 때 : post방식
 */
@Controller
public class MemberController {

    private final MemberService memberService;

    //spring container에서 memberService를 가져옴.
    @Autowired //service와 controller를 연결. MemberController가 생성이 될 때, spring bean에 등록이 되어 있는 객체를 가져다가 넣어줌.
    public MemberController(MemberService memberService) {
        this.memberService = memberService;
    }

    @GetMapping("/members/new")
    public String createForm() {
        return "members/createMemberForm";
    }


    @PostMapping("/members/new")
    public String create(MemberFrom form){
        Member member = new Member();
        member.setName(form.getName());
        System.out.println(member.getName());
        memberService.join(member);

        return "redirect:/";
    }

    @GetMapping("/members")
    public String list(Model model) {
        List<Member> members = memberService.findMembers();
        model.addAttribute("members", members);
        return "members/memberList";
    }
}

public class Injector {

   public AuthWindow enter() {
       AuthWindow chow = new chow();
       AuthWindow enter_pin_code = new enter_pin_code();
       AuthControl check = new check_pin(Card id_card, Card pin_code);
       AuthControl check_log = new auth();
       AuthWindow create_option_win = new create_option_win();h
   }

   public OptionWindow Menu() {
       OptionWindow take_cash = new take_cash_win();
       OptionWindow pay_number = new pay_number();
       OptionWindow chow = new chow();
       OptionWindow button = new button_cliker();
       OptionWindow entering = new entering();
       Controller auth = new create_auth_contr();
       Controller service = new service_controller();
       Controller take_cash = new take_cash();
       Controller bankomate_state = new bankomate_state();
       OptionWindow close = new close();
   }
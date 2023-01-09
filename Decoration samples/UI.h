#include <iostream>
#include <memory>
#include <string>

class Interface
{
public:
    virtual ~Interface() = default;
    virtual void doThis() = 0;
};

class Core : public Interface
{
private:
    std::string id;
    std::string password;

public:
    int tell_number;
    float count;
    ~Core() override;
    void doThis() override;

    void login(std::string id, std::string password);
    void MainWindow();
    void get_mony(float count);
    void pay_telephon(int tell_number, float count);
    void operation_state();
    void bankomat_state();
};

class Decorator : public Interface
{
private:
    std::unique_ptr< Interface > interface;

public:
    Decorator( std::unique_ptr< Interface > c );
    void doThis() override;
};

class Card_bloker : public Decorator
{
private:
    int iteration;

public:
    Card_bloker( std::unique_ptr< Interface > c, int& iteration);
    ~Card_bloker() override;
    void doThis() override;

};

class Place_card : public Decorator
{
private:
    std::string place;

public:
    Place_card( std::unique_ptr< Interface > c, const std::string& str );
    ~Place_card() override;
    void doThis() override;
};

class Valyuta : public Decorator
{
private:
    std::string valyuta_type;

public:
    Valyuta( std::unique_ptr< Interface > c, const std::string& str );
    ~Valyuta() override;
    void doThis() override;
};

class Injector
{
public:
    void run();
};

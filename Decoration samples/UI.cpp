#include "decorator.h"

#include <iostream>
#include <memory>
#include <string>

Core::~Core()
{
    std::cout << "Core destructor called.\n";
}

void Core::doThis(){}; // Do nothing.

Decorator::Decorator( std::unique_ptr< Interface > c )
{
    interface = std::move( c );
}
void Decorator::doThis()
{
    interface->doThis();
}

Card_bloker::Card_bloker( std::unique_ptr< Interface > c
                         , int& iteration )
    : Decorator( std::move( c ) )
    , iteration()
{
}
Card_bloker::~Card_bloker()
{
    std::cout << "Messenger destructor called.\n";
}
void Card_bloker::doThis()
{

    Decorator::doThis();
}

Place_card::Place_card( std::unique_ptr< Interface > c
                      , const std::string& str )
                      : Decorator( std::move( c ) )
                      , place( str )
{

}
Place_card::~Place_card()
{
    std::cout << "MessengerWithValediction destructor called.\n";
}
void Place_card::doThis()
{
    Decorator::doThis();
}

Valyuta::Valyuta( std::unique_ptr< Interface > c
                       , const std::string& str )
    : Decorator( std::move( c ) )
    , valyuta_type( str )
{

}
Valyuta::~Valyuta()
{
    std::cout << "MessengerWithValediction destructor called.\n";
}
void Valyuta::doThis()
{
    Decorator::doThis();
}

void Injector::run()
{
    int iteration = 3;
    std::string place = "Belinvest Bank";
    std::string valyuta_type = "Dollar";

    std::unique_ptr< Interface > messenger1 = std::make_unique< Core >();
    std::unique_ptr< Interface > messenger2 = std::make_unique< Card_bloker >( std::make_unique< Core >(), iteration );
    std::unique_ptr< Interface > messenger3 = std::make_unique< Place_card >( std::make_unique< Core >(), place );
    std::unique_ptr< Interface > messenger4 = std::make_unique< Valyuta >( std::make_unique< Core >(), valyuta_type );

    messenger1->doThis();
    messenger2->doThis();
    messenger3->doThis();
    messenger4->doThis();

}

using NewsletterSubscription;
using NewsletterSubscription.Implementations;
using NewsletterSubscription.Interfaces;
using NewsletterSubscription.Model;
using NewsPaper;

IEmailService emailService = Factory.CreateEmailService();
ISubscriptionRepository subscriptionRepo = Factory.CreateSubscriptionRepository();

var subscriptionService = new SubscriptionService(emailService, subscriptionRepo);

while (true)
{
    Console.Write("Meny:\n1: Melde på nyhetsbrev\n2: Verifisere\n");
    var choice = Console.ReadLine();
    if (choice == "1")
    {
        Console.Write("Skriv inn epostadresse: ");
        var emailAddress = Console.ReadLine();

        Console.Write("Skriv inn navn: ");
        var name = Console.ReadLine();

        subscriptionService.Subscribe(name, emailAddress);
    }
    else if (choice == "2")
    {
        Console.Write("Skriv inn epostadresse: ");
        var emailAddress = Console.ReadLine();

        Console.Write("Skriv inn verifikasjonskode: ");
        var code = Console.ReadLine();

        subscriptionService.Verify(emailAddress, code);
    }
}


// Demo code:

IEmail email = Factory.CreateEmail(
    "per@getacademy.no",
    "pål@getacademy.no",
    "Hei",
    "Tekst...");

emailService.Send(email);

var subscription = Factory.CreateSubscription("Terje", "terje@getacademy.no");
subscriptionRepo.Save(subscription);

subscription = subscriptionRepo.Load("terje@getacademy.no");
Console.WriteLine(subscription);
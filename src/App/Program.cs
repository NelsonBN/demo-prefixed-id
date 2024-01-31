using PrefixedId;

Console.WriteLine(SubscriptionId.Create());

SubscriptionId id1 = "sub_12345678901234567890123456789012";
Console.WriteLine(id1);

SubscriptionId id2 = "sub_12345678901234567890123456789012";
Console.WriteLine(id2);

var d3 = SubscriptionId.Parse("sub_12345678901234567890123456789012");
Console.WriteLine(d3);

Console.WriteLine(SubscriptionId.IsValid("sub_12345678901234567890123456789012"));
Console.WriteLine(SubscriptionId.IsValid("ub_12678901234567890123456789012"));

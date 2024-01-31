using PrefixedId;

namespace Tests;

public class Test
{
    [Theory]
    [InlineData("sub_12345678901234567890123456789012")]
    [InlineData("sub_00000000000000000000000000000000")]
    [InlineData("sub_1234567890123456789012345678901a")]
    public void When_passing_a_valid_string_id_create_a_new_object_id(string id)
    {
        // Arrange
        SubscriptionId subscriptionId = id;


        // Act
        string act = subscriptionId;


        // Assert
        act.Should().Be(id);
    }

    [Theory]
    [InlineData("sub_12345678901234567890123456789012")]
    [InlineData("sub_00000000000000000000000000000000")]
    [InlineData("sub_1234567890123456789012345678901a")]
    public void When_passing_a_valid_span_id_create_a_new_object_id(string id)
    {
        // Arrange
        SubscriptionId subscriptionId = id.AsSpan();


        // Act
        string act = subscriptionId;


        // Assert
        act.Should().Be(id.ToString());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("sub_abcdefghijklmnopqrstuvwxyz012345")]
    [InlineData("pub_12345678901234567890123456789012")]
    [InlineData("sub_1234567890234567890123456789012")]
    [InlineData("sub_123456789023456789012345678901211")]
    [InlineData("sub_123456789023456789012345678901<11")]
    [InlineData("sub_123456789z1234567890123456789012")]
    [InlineData("sub_")]
    [InlineData("sub_12345678901234567890123456789")]
    [InlineData("sub_123456789012345678901234567890123")]
    [InlineData("sub_1234567890123456789012345678901<")]
    [InlineData("sub_1234567890123456789012345678901!")]
    [InlineData("sub_1234567890123456789012345678901@")]
    public void When_passing_a_invalid_string_id_create_a_throw_exception(string? id)
    {
        // Arrange && Act
        var act = () => { SubscriptionId subscriptionId = id; };


        // Assert
        act.Should()
            .Throw<ArgumentException>(id)
            .WithMessage("Invalid SubscriptionId (Parameter 'SubscriptionId')");
    }
}

import random

def guessing_game():
    """
    Runs a number guessing game where the player tries to guess a randomly selected number between 1 and 100.
    Provides feedback based on the player's guesses and motivational messages.
    """
    print("Welcome to the Number Guessing Game!")
    
    # Generate a random number between 1 and 100
    number_to_guess = random.randint(1, 100)
    attempts = 0

    # Define a list of motivational messages
    messages = [
        "Keep going, you can do it!",
        "Don't give up, you're close!",
        "Great effort! Try again!"
    ]

    # Define a dictionary for feedback based on attempts
    feedback = {
        "fast": "Amazing! You guessed the number super quickly!",
        "average": "Good job! You guessed it in a decent number of attempts.",
        "slow": "You got it, but it took some perseverance!"
    }

    while True:
        try:
            # Get user input and ensure it is an integer
            user_guess = int(input("Guess a number between 1 and 100: "))
            attempts += 1

            # Check the guess and provide feedback
            if user_guess < number_to_guess:
                print("Too low! Try again.")
                print(random.choice(messages))
            elif user_guess > number_to_guess:
                print("Too high! Try again.")
                print(random.choice(messages))
            else:
                # Provide feedback based on the number of attempts
                if attempts <= 3:
                    print(feedback["fast"])
                elif attempts <= 7:
                    print(feedback["average"])
                else:
                    print(feedback["slow"])
                print(f"Congratulations! You guessed the number in {attempts} attempts.")
                return attempts  # Return attempts count for tracking
        except ValueError:
            print("Invalid input. Please enter a valid number.")

def display_statistics(attempts_list):
    """
    Displays game statistics including the total games played, best game (fewest attempts), and average attempts.
    """
    print("\nGame Statistics:")
    print(f"Total games played: {len(attempts_list)}")
    print(f"Best game (fewest attempts): {min(attempts_list)} attempts")
    print(f"Average attempts per game: {sum(attempts_list) / len(attempts_list):.2f}")

def main():
    """
    Main function to run the game loop, track attempts, and display statistics after playing.
    """
    attempts_list = []  # List to store attempts for each game
    
    while True:
        attempts = guessing_game()  # Run the game and get attempts count
        attempts_list.append(attempts)  # Store attempts for statistics
        
        play_again = input("Would you like to play again? (yes/no): ").strip().lower()
        
        if play_again == "no":
            display_statistics(attempts_list)  # Show stats before exiting
            print("Thank you for playing! Goodbye!")
            break
        elif play_again != "yes":
            print("Invalid input. Please enter 'yes' or 'no'.")

if __name__ == "__main__":
    main()

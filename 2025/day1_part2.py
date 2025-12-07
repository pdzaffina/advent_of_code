# %%
# import

# %%
# Initialize your position to 50 and your counter to 0.
position = 50
counter = 0

# %%
# Parse the line to get the direction ('L' or 'R') and the number of clicks.

def line_parser(line):
    direction = line[0]
    number = int(line[1:])
    return direction, number

# %%
# Loop through every line in your input data.
input = "day1_input.txt"
with open(input) as f:
    lines = f.readlines()

# %%
for l in lines:
    direction, number = line_parser(l.strip())

    # Calculate how many full circles are in 'number' using integer division (//).
    # Add that result directly to 'counter'.

    full_circles = number // 100
    counter += full_circles

    # Calculate the leftover clicks using modulo (number % 100).
    # Determine the step direction: +1 for 'R', -1 for 'L'.
    remainder = number % 100
    step = 1 if direction == 'R' else -1

    # Create a loop that runs 'remainder' times.
    # Inside this inner loop:
    #    a. Update 'position' by the step (+1 or -1).
    #    b. Apply modulo 100 to 'position'.
    #    c. Check if 'position' == 0. If yes, increment 'counter'.
    for _ in range(remainder):
        position = (position + step) % 100
        if position == 0:
            counter += 1
    
# %%

# Result: The final value of counter is your answer.

print("Final counter value:", counter)

# %%
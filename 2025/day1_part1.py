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
input = "day1_sample_input.txt"
with open(input) as f:
    lines = f.readlines()

# %%
for l in lines:
    direction, number = line_parser(l.strip())
    
    # Update the position variable:
    #   - If R: Add the number to position, then apply modulo 100.
    #   - If L: Subtract the number from position, then apply modulo 100.
    
    if direction == 'R':
        position = (position + number) % 100
    elif direction == 'L':
        position = (position - number) % 100
    
    # Check: Immediately after updating the position, check if the position is exactly 0.
    #   - If it is, increment your counter by 1.
    if position == 0:
        counter += 1
# %%

# Result: The final value of counter is your answer.

print("Final counter value:", counter)

# %%
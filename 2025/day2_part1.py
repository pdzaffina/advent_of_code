# %%
input_file_path = 'day2_input.txt'

# Initialize total_sum = 0.
total_sum = 0

# Read input and split by ,.
with open(input_file_path, 'r') as file:
    data = file.read().strip()
range_strings = data.split(',')

# For each range string:
#   Parse start and end.
for range_string in range_strings:
    start_str, end_str = range_string.split('-')
    start = int(start_str)
    end = int(end_str)

    #   For current_num from start to end:
    for current_num in range(start, end + 1):
        #   Convert current_num to string.
        current_num_str = str(current_num)

        #   If length is even AND first half equals second half:
        if len(current_num_str) % 2 == 0:
            half_length = len(current_num_str) // 2
            first_half = current_num_str[:half_length]
            second_half = current_num_str[half_length:]

            if first_half == second_half:
                # Add current_num to total_sum.
                total_sum += current_num

# Print total_sum.
print("Total sum is: ", total_sum)


# %%
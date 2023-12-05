(ns clojure-code.day1.day1
  (:gen-class)
  (:require [clojure.string :as str]))

(def sample-input (str/split-lines (slurp "./resources/day1/sample-input.txt")))

(def sample-input2 (str/split-lines (slurp "./resources/day1/sample-input2.txt")))

(def input (str/split-lines (slurp "./resources/day1/input.txt")))

; Define a function to replace written-out digits with numeric representations
(defn replace-written-digits [s]
  (-> s
      (str/replace #"one" "one1one")
      (str/replace #"two" "two2two")
      (str/replace #"three" "three3three")
      (str/replace #"four" "four4four")
      (str/replace #"five" "five5five")
      (str/replace #"six" "six6six")
      (str/replace #"seven" "seven7seven")
      (str/replace #"eight" "eight8eight")
      (str/replace #"nine" "nine9nine")
      (str/replace #"zero" "zero0zero")))


; Define a function to extract the first and last digits from a line and calculate the sum
(defn sum-of-calibration-values [lines]
  (->> lines
       (map replace-written-digits)
       (map #(re-seq #"\d" %))
       (map #(Integer. (str (first %) (last %)))) ; Extract and convert to integers
       (apply +)))                                ; Sum the values

; Calculate the sum of all calibration values
(def result (sum-of-calibration-values input))

; Output the result
(println result)

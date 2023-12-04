(ns clojure-code.day1.day1
  (:gen-class)
  (:require [clojure.string :as str]))

;; Day 1 Part 1

;; Get the input text and convert to string
(def input (str/split-lines (slurp "./resources/day1/input.txt")))

;; Define a function to extract the first and last digits from a line and calculate the sum
(defn sum-of-calibration-values [lines]
  (->> lines
       (map #(re-seq #"\d" %))                    ; Extract all digits from the text
       (map #(Integer. (str (first %) (last %)))) ; Extract and convert to integers
       (apply +)))                                ; Sum the values

;; Calculate the sum of all calibration values
(def result (sum-of-calibration-values input))

;; Output the result
(println result)
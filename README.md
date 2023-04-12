# MMORPGKIT Chat Filter and Replace Bad Words Addon
 A custom addon for the MMORPGKIT to let you filter bad words in chat and replace them with specific character (i.e. profanity filter for chat).
 Mostly plug and play with one-line change in the kit's core code.
  
## Preview ##
![image](https://user-images.githubusercontent.com/3790163/231526760-ae9615fa-29fd-4bbd-ad7a-f52e466f2810.png)

![image](https://user-images.githubusercontent.com/3790163/231526838-9c2b0d69-9d55-41c6-9fc8-c6ab6ff250c4.png)

![image](https://user-images.githubusercontent.com/3790163/231526932-3d2bda99-f245-46a4-adc2-2e9dbf9de168.png)


 
## Features: ##
1. Lets you filter the chat in your game againsr specific bad words and replace them (whole word) with specific character.
2. Mostly plug and play, requires a single line addition in the kit's core code
3. Can be used with any chat systems
4. Lets you use your own profanity/bad word list or any list publicly
5. Come's with a nifty editor tool to let you instantly parse and use a list/string of bad words separated by new lines (it will auto-fill those words into the filter words array)

## How to use: ##
1. The addon is plug and play and uses a partial class of `UIChatHandler`, just drop it in your project.
2. Open `UIChatHandler.cs` class file of the kit, find `OnReceiveChat()` method (line 250~) in the class and add below code in `OnReceiveChat()` to call the `FilterBadWords()` method
```
//TODO: #COREEDIT: Filter and Censor bad words in chat message
chatMessage = FilterBadWords(chatMessage);
```
3. If using any other chat system, you can similarly call the `FilterBadWords()` method passing it the chat message string

![image](https://user-images.githubusercontent.com/3790163/231526526-9baaf9b2-e7c0-47d9-8f16-2e5b9a44a2c5.png)

## Sample Bad Words List You Can Use ##
`https://github.com/LDNOOBW/List-of-Dirty-Naughty-Obscene-and-Otherwise-Bad-Words/blob/master/en`

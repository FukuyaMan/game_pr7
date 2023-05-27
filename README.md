# pr_game7

なんちゃってInvader Gameです  
[ゲームはここから](https://fukuyaman.github.io/build_pr7/)  
コードは行き当たりばったり試行錯誤して作り上げたので汚いし読みにくいしバグもあるしで散々なものです  
作り直すことはあるかもしれませんがこのコード自体を修正することはないと思います

## Assets下のフォルダ構成

projectフォルダの下にシーン間で統合できそうな音楽，画像などはAudio, Designにそれぞれ入れる  
programフォルダの下にはシーンごとにScripts, Materials, シーンファイルを入れる

そんな構成でやってみました，初めての試みだったのと単純なシーンしかなかったからうまく使いこなせてなさそう  
[こちらを参考にさせていただきますた](https://r-ngtm.hatenablog.com/entry/2017/12/19/225951)

## 使用した画像

インベーダーゲームのプレイ動画に映っていた敵を見ながら見様見真似でドットを打ったものを使用した

## 現在見つかっている課題

- カーソルの丸をUIの一部としてではなく独立したオブジェクトとして設定しているためContinue画面で解像度を変えると場所がずれる
    - 私の環境では，ブラウザの拡大率を80%にしたときちょうどよくなる
- 一画面でプレイヤーが打てる弾は一発だけにしていたはずが，敵を弾１発で２体以上倒した時(原因が本当にこれであるかは不明)になぜか上限を超えて弾が打てるようになる不具合
    - 正規の方法でゲームをクリアすることができなさそうなので，正直この不具合は必須テクニックかもしれない

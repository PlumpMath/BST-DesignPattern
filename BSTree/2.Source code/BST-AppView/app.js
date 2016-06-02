$(document).ready(function() {
  $('#btn-create').click(function() {
    // drawLine('#l00t');
    let tree = {
      key: 12,
      level: 0,
      order: 1,
      left: {
        key: 9,
        level: 1,
        order: 1,
        left: {
          key: 7,
          order: 1,
          level: 2,
          left: null,
          right: null
        },
        right: {
          key: 11,
          level: 2,
          order: 2,
          left: {
            key: 10,
            level: 3,
            order: 3,
            left: null,
            right: null
          },
          right: null
        }
      },
      right: {
        key: 20,
        level: 1,
        order: 2,
        left: {
          key: 16,
          level: 2,
          order: 3,
          lef: null,
          right: {
            key: 18,
            level: 3,
            order: 6,
            left: null,
            right: null
          }
        },
        right: {
          key: 23,
          level: 2,
          order: 4,
          left: null,
          right: null
        }
      }
    };
    drawTree(tree);
  });
  // draw tree
  function drawTree(tree) {
    drawTreeLine(tree);
    drawTreeNode(tree);
  }

  function drawTreeNode(tree) { // ve node cua cay
    if (tree == null) {
      return;
    }
    drawNode(tree);
    drawTree(tree.left);
    drawTree(tree.right);
  }

  function drawTreeLine(tree) { // ve line cua cay
    if (tree == null) {
      return;
    }
    drawLine(tree, tree.left);
    drawLine(tree, tree.right);
    drawTreeLine(tree.left);
    drawTreeLine(tree.right);
  }

  function SVG(tag) { // tao doi tuong
    return document.createElementNS('http://www.w3.org/2000/svg', tag);
  }
  var center = 360;
  // draw functions
  // draw node
  function getFirstX(level) { // lay x cua node dau tien moi level
    return (center / Math.pow(2, level));
  }

  function createText(str) { // tao text trong node
    var newText = SVG('text');
    newText.setAttributeNS(null, "x", 0);
    newText.setAttributeNS(null, "y", 5);
    var textNode = document.createTextNode(str);
    newText.appendChild(textNode);
    return newText;
  }

  function getXNode(node) { // lay toa do x cua node
    return getFirstX(node.level) * (2 * node.order - 1);
  }

  function getYNode(node) { // lay toa do y cua node
    return 40 + (100 * node.level);
  }

  function drawNode(node) { // ve node
    // tinh toa do
    let x = getXNode(node);
    let y = getYNode(node);
    let $svg = $('#svgPanel');
    let $g = $(SVG('g')).attr('transform', "translate(" + x + "," + y + ")");
    let $circle = $(SVG('circle')).attr('cx', 0).attr('cy', 0).attr('r', 22.5).attr('fill', '#FFF').attr('stroke', '#666').attr('stroke-width', 3).appendTo($g);
    let $text = $(createText(node.key)).attr("style", "z-index: 2; fill: #666; font-size: 1em; font-weight: normal; font-style: normal; opacity: 1; text-anchor: middle;").appendTo($g);
    $g.appendTo($svg);
  }
  // drawLine 
  function drawLine(src, des) { // tryen vao 1 node
    if (des == null) {
      return;
    }
    // tinh toa do
    let xsrc = getXNode(src);
    let ysrc = getYNode(src);
    let xdes = getXNode(des);
    let ydes = getYNode(des);
    let $svg = $('#svgPanel');
    let $line = $(SVG('path')).attr('d', "M" + xsrc + "," + ysrc + " " + "L" + xdes + "," + ydes).attr("style", "stroke:#666; fill:none; stroke-width: 3;");
    $line.appendTo($svg);
  }
  // drawLine Animation
  function drawLineAni(idString) { // ve line
    $(idString).show();
    let path = document.querySelector(idString);
    let length = path.getTotalLength();
    // Clear any previous transition
    path.style.transition = path.style.WebkitTransition = 'none';
    // Set up the starting positions
    path.style.strokeDasharray = length + ' ' + length;
    path.style.strokeDashoffset = length;
    // Trigger a layout so styles are calculated & the browser
    // picks up the starting position before animating
    path.getBoundingClientRect();
    // Define our transition
    path.style.transition = path.style.WebkitTransition = 'stroke-dashoffset 2s ease-in-out';
    // Go!
    path.style.strokeDashoffset = '0';
  }
});
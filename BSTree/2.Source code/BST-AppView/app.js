$(document).ready(function() {
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
        left: {
          key: 21,
          level: 3,
          order: 7,
          left: null,
          right: null
        },
        right: null
      }
    }
  };
  $('#btn-create').click(function() {
    drawTree(tree);
  });
  $('#btn-insert').click(function() {
    if (!$('#insert-key').val()) {
      alert("Please enter a key");
      return;
    }
    insertNode($('#insert-key').val(), tree);
  });
  $('#btn-find').click(function() {
    if (!$('#find-key').val()) {
      alert("Please enter a key");
      return;
    }
    findNode($('#find-key').val(), tree);
  });
  $('#btn-get-max').click(function() {
    getMax(tree);
  });
  $('#btn-get-min').click(function() {
    getMin(tree);
  });
  $('#btn-min-right').click(function() {
    getMinOfRight(tree);
  });
  $('#btn-max-left').click(function() {
    getMaxOfLeft(tree);
  });
  $('#btn-show-order').click(function() {
    // showOrderLNR(tree.left, tree);
    if ($('#order-value').val() == "L-N-R") {
      showOrderLNR(tree);
    }
    if ($('#order-value').val() == "N-L-R") {
      showOrderNLR(tree);
    }
    if ($('#order-value').val() == "L-R-N") {
      showOrderLRN(tree);
    }
  });
  ////////////////////////////// draw tree //////////////////////////////
  function drawTree(tree) {
    drawTreeLine(tree);
    drawTreeNode(tree);
  }

  function drawTreeNode(tree) { // ve node cua cay
    if (tree == null) {
      return;
    }
    drawNode(tree, '#666');
    drawTree(tree.left);
    drawTree(tree.right);
  }

  function drawTreeLine(tree) { // ve line cua cay
    if (tree == null) {
      return;
    }
    drawLine(tree, tree.left, '#666');
    drawLine(tree, tree.right, '#666');
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

  function drawNode(node, color) { // ve node
    // tinh toa do
    let x = getXNode(node);
    let y = getYNode(node);
    let $svg = $('#svgPanel');
    let $g = $(SVG('g')).attr('transform', "translate(" + x + "," + y + ")");
    let $circle = $(SVG('circle')).attr('cx', 0).attr('cy', 0).attr('r', 22.5).attr('fill', '#FFF').attr('stroke', color).attr('stroke-width', 3).appendTo($g);
    let $text = $(createText(node.key)).attr("style", "z-index: 2; fill: #666; font-size: 1em; font-weight: normal; font-style: normal; opacity: 1; text-anchor: middle;").appendTo($g);
    $g.appendTo($svg);
  }
  // drawLine 
  function drawLine(srcNode, desNode, color) { // tryen vao 1 node
    if (desNode == null) {
      return;
    }
    // tinh toa do
    let idString = "";
    let display = "";
    if (color != "#666") {
      idString = "f" + srcNode.level + srcNode.order + "t" + desNode.level + desNode.order;
      display = "display: none;";
    }
    let xsrc = getXNode(srcNode);
    let ysrc = getYNode(srcNode);
    let xdes = getXNode(desNode);
    let ydes = getYNode(desNode);
    let $svg = $('#svgPanel');
    let $line = $(SVG('path')).attr('d', "M" + xsrc + "," + ysrc + " " + "L" + xdes + "," + ydes).attr("id", idString).attr("style", "stroke:" + color + "; fill:none; stroke-width: 3; " + display + '"');
    $line.appendTo($svg);
    drawNode(srcNode);
  }
  // drawLine Animation
  function drawLineAni(srcNode, desNode) { // ve line
    let idString = "f" + srcNode.level + srcNode.order + "t" + desNode.level + desNode.order;
    $("#" + idString).show();
    let path = document.querySelector("#" + idString);
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
    path.style.transition = path.style.WebkitTransition = 'stroke-dashoffset 1s ease-in-out';
    // Go!
    path.style.strokeDashoffset = '0';
  }
  // show node
  function showNode(key) {
    let $svg = $('#svgPanel');
    let $g = $(SVG('g')).attr('transform', "translate(" + 45 + "," + 40 + ")");
    let $circle = $(SVG('circle')).attr('cx', 0).attr('cy', 0).attr('r', 22.5).attr('fill', '#FFF').attr('stroke', '#dd1b16').attr('stroke-width', 3).appendTo($g);
    let $text = $(createText(key)).attr("style", "z-index: 2; fill: #666; font-size: 1em; font-weight: normal; font-style: normal; opacity: 1; text-anchor: middle;").appendTo($g);
    $g.appendTo($svg);
  }
  ////////////////////////////// insert a node //////////////////////////////
  // insert node
  function insertNode(key, tree) {
    $('.log').append("<div class='log-item'>START to INSERT node " + key + "</div>");
    showNode(key);
    insertNodeProcess(key, tree);
  }

  function insertNodeProcess(key, tree) {
    drawNode(tree, '#dd1b16');
    let newNode = {};
    if (key < tree.key) { // trai
      $('.log').append("<div class='log-item'>" + key + " < " + tree.key + " --> Go to LEFT</div>");
      if (tree.left == null) { // ve node trai
        newNode = {
          key: key,
          level: tree.level + 1,
          order: (2 * tree.order) - 1,
          left: null,
          right: null
        };
        drawLine(tree, newNode, '#dd1b16');
        drawLineAni(tree, newNode);
        setTimeout(function() {
          drawNode(newNode, '#1b72e2');
          $('.log').append("<div class='log-item'>Draw Node: " + key + "</div>");
          $('.log').append("<div class='log-item'>FINISH</div>");
          return;
        }, 1000);
      } else { // duyet trai
        drawLine(tree, tree.left, '#dd1b16');
        drawLineAni(tree, tree.left);
        setTimeout(function() {
          insertNodeProcess(key, tree.left);
        }, 1000);
      }
    } else { // phai
      $('.log').append("<div class='log-item'>" + key + " >= " + tree.key + " --> Go to RIGHT</div>");
      if (tree.right == null) {
        newNode = {
          key: key,
          level: tree.level + 1,
          order: (2 * tree.order),
          left: null,
          right: null
        };
        drawLine(tree, newNode, '#dd1b16');
        drawLineAni(tree, newNode);
        setTimeout(function() {
          drawNode(newNode, '#1b72e2');
          $('.log').append("<div class='log-item'>Draw Node: " + key + "</div>");
          $('.log').append("<div class='log-item'>FINISH</div>");
          return;
        }, 1000);
      } else {
        drawLine(tree, tree.right, '#dd1b16');
        drawLineAni(tree, tree.right);
        setTimeout(function() {
          insertNodeProcess(key, tree.right);
        }, 1000);
      }
    }
  }
  ////////////////////////////// find a node //////////////////////////////
  function findNode(key, tree) {
    $('.log').append("<div class='log-item'>START to FIND node " + key + "</div>");
    showNode(key);
    findNodeProcess(key, tree);
  }

  function findNodeProcess(key, tree) {
    drawNode(tree, '#dd1b16');
    if (key < tree.key) { // trai
      $('.log').append("<div class='log-item'>" + key + " < " + tree.key + " --> Go to LEFT</div>");
      if (tree.left == null) { // khong tim thay
        $('.log').append("<div class='log-item'>Node " + key + " NOT found</div>");
        $('.log').append("<div class='log-item'>FINISH</div>");
        return;
      } else { // duyet trai
        drawLine(tree, tree.left, '#dd1b16');
        drawLineAni(tree, tree.left);
        setTimeout(function() {
          findNodeProcess(key, tree.left);
        }, 1000);
      }
    }
    if (key > tree.key) { // phai
      $('.log').append("<div class='log-item'>" + key + " > " + tree.key + " --> Go to RIGHT</div>");
      if (tree.right == null) {
        $('.log').append("<div class='log-item'>Node " + key + " NOT found</div>");
        $('.log').append("<div class='log-item'>FINISH</div>");
        return;
      } else {
        drawLine(tree, tree.right, '#dd1b16');
        drawLineAni(tree, tree.right);
        setTimeout(function() {
          findNodeProcess(key, tree.right);
        }, 1000);
      }
    }
    if (key == tree.key) { // bang
      $('.log').append("<div class='log-item'>" + key + " = " + tree.key + "</div>");
      $('.log').append("<div class='log-item'>Node " + key + " was found</div>");
      $('.log').append("<div class='log-item'>FINISH</div>");
      drawNode(tree, "#1b72e2");
    }
  }
  ////////////////////////////// Get max //////////////////////////////
  function getMax(tree) {
    $('.log').append("<div class='log-item'>START to GET MAX</div>");
    getMaxProcess(tree);
  }

  function getMaxProcess(tree) {
    drawNode(tree, '#dd1b16');
    if (tree.right == null) { // khong tim thay
      drawNode(tree, "#1b72e2");
      $('.log').append("<div class='log-item'>Result: " + tree.key + "</div>");
      $('.log').append("<div class='log-item'>FINISH</div>");
      return;
    } else { // duyet phai
      $('.log').append("<div class='log-item'>Node " + tree.key + " --> Go to RIGHT</div>");
      drawLine(tree, tree.right, '#dd1b16');
      drawLineAni(tree, tree.right);
      setTimeout(function() {
        getMaxProcess(tree.right);
      }, 1000);
    }
  }
  ////////////////////////////// Get min //////////////////////////////
  function getMin(tree) {
    $('.log').append("<div class='log-item'>START to GET MIN</div>");
    getMinProcess(tree);
  }

  function getMinProcess(tree) {
    drawNode(tree, '#dd1b16');
    if (tree.left == null) { // khong tim thay
      drawNode(tree, "#1b72e2");
      $('.log').append("<div class='log-item'>Result: " + tree.key + "</div>");
      $('.log').append("<div class='log-item'>FINISH</div>");
      return;
    } else { // duyet trai
      $('.log').append("<div class='log-item'>Node " + tree.key + " --> Go to LEFT</div>");
      drawLine(tree, tree.left, '#dd1b16');
      drawLineAni(tree, tree.left);
      setTimeout(function() {
        getMinProcess(tree.left);
      }, 1000);
    }
  }
  ////////////////////////////// Get min of RIGHT //////////////////////////////
  function getMinOfRight(tree) {
    drawNode(tree, '#dd1b16');
    $('.log').append("<div class='log-item'>START to GET MIN of RIGHT</div>");
    if (tree.right == null) {
      drawNode(tree, "#1b72e2");
      $('.log').append("<div class='log-item'>Result: " + tree.key + "</div>");
      $('.log').append("<div class='log-item'>FINISH</div>");
      return;
    } else {
      drawLine(tree, tree.right, '#dd1b16');
      drawLineAni(tree, tree.right);
      setTimeout(function() {
        getMinProcess(tree.right);
      }, 1000);
    }
  }
  ////////////////////////////// Get max of Lef //////////////////////////////
  function getMaxOfLeft(tree) {
    drawNode(tree, '#dd1b16');
    $('.log').append("<div class='log-item'>START to GET MAX of LEFT</div>");
    if (tree.left == null) {
      drawNode(tree, "#1b72e2");
      $('.log').append("<div class='log-item'>Result: " + tree.key + "</div>");
      $('.log').append("<div class='log-item'>FINISH</div>");
      return;
    } else {
      drawLine(tree, tree.left, '#dd1b16');
      drawLineAni(tree, tree.left);
      setTimeout(function() {
        getMaxProcess(tree.left);
      }, 1000);
    }
  }
  ////////////////////////////// Show ORDER //////////////////////////////
  function showOrder(tree, order) {}

  function showOrderLNR(tree) {
    if (tree == null) {
      return;
    }
    showOrderLNR(tree.left);
    $('.log').append("<div class='log-item'>" + tree.key + "</div>");
    drawNode(tree, '#dd1b16');
    showOrderLNR(tree.right);
  }

  function showOrderNLR(tree) {
    if (tree == null) {
      return;
    }
    $('.log').append("<div class='log-item'>" + tree.key + "</div>");
    drawNode(tree, '#dd1b16');
    showOrderNLR(tree.left);
    showOrderNLR(tree.right);
  }

  function showOrderLRN(tree) {
    if (tree == null) {
      return;
    }
    showOrderLRN(tree.left);
    showOrderLRN(tree.right);
    $('.log').append("<div class='log-item'>" + tree.key + "</div>");
    drawNode(tree, '#dd1b16');
  }
});
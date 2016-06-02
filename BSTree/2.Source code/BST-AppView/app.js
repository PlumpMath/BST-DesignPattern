$(document).ready(function() {
  $('#btn-create').click(function() {
    // drawLine('#l00t');
    let tree = {
      key: 12,
      left: {
        key: 9,
        left: {
          key: 7,
          left: null,
          right: null
        },
        right: {
          key: 11,
          left: {
            key: 10,
            left: null,
            right: null
          },
          right: null
        }
      },
      right: {
        key: 20,
        left: {
          key: 16,
          lef: null,
          right: {
            key: 18,
            left: null,
            right: null
          }
        },
        right: {
          key: 23,
          left: null,
          right: null
        }
      }
    };
    drawNode(node);
  });
  // refactor tree
  function refactorTree(tree) {
    let level =0;
    let order = 1;
    let currNode = tree;
    
  }

  function SVG(tag) {
    return document.createElementNS('http://www.w3.org/2000/svg', tag);
  }
  var center = 360;
  // draw functions
  // draw node
  function getFirstX(level) {
    return (center / Math.pow(2, level));
  }

  function createText(str) {
    var newText = SVG('text');
    newText.setAttributeNS(null, "x", 0);
    newText.setAttributeNS(null, "y", 5);
    var textNode = document.createTextNode(str);
    newText.appendChild(textNode);
    return newText;
  }

  function drawNode(node) {
    // tinh toa do
    let x = getFirstX(node.level) * (2 * node.order - 1);
    let y = 40 + (100 * node.level);
    let $svg = $('#svgPanel');
    let $g = $(SVG('g')).attr('transform', "translate(" + x + "," + y + ")");
    let $circle = $(SVG('circle')).attr('cx', 0).attr('cy', 0).attr('r', 22.5).attr('fill', 'none').attr('stroke', 'red').attr('stroke-width', 3).appendTo($g);
    let $text = $(createText(node.key)).attr("style", "z-index: 2; fill: #666; font-size: 1em; font-weight: normal; font-style: normal; opacity: 1; text-anchor: middle;").appendTo($g);
    $g.appendTo($svg);
  }
  // drawLine
  function drawLine(idString) {
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